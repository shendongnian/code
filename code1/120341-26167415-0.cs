    #pragma once
    #include <Windows.h>	// Declares required datatypes.
    #include <Dbt.h>		// Required for WM_DEVICECHANGE messages.
    #include <initguid.h>	// Required for DEFINE_GUID definition (see below).
    namespace USBComms 
    {
    	using namespace System;
    	using namespace System::Runtime::InteropServices;
    	using namespace System::Windows;
    	using namespace System::Windows::Forms;
    	// This function is required for receieving WM_DEVICECHANGE messages.
    	// Note: name is remapped "RegisterDeviceNotificationUM"
    	[DllImport("user32.dll" , CharSet = CharSet::Unicode, EntryPoint="RegisterDeviceNotification")]					
    	extern "C" HDEVNOTIFY WINAPI RegisterDeviceNotificationUM(
    		HANDLE hRecipient,
    		LPVOID NotificationFilter,
    		DWORD Flags);
    	// Generic guid for usb devices (see e.g. http://msdn.microsoft.com/en-us/library/windows/hardware/ff545972%28v=vs.85%29.aspx).
    	// Note: GUIDs are device and OS specific and may require modification. Using the wrong guid will cause notification to fail.
    	// You may have to tinker with your device to find the appropriate GUID. "hid.dll" has a function `HidD_GetHidGuid' that returns
    	// "the device interfaceGUID for HIDClass devices" (see http://msdn.microsoft.com/en-us/library/windows/hardware/ff538924%28v=vs.85%29.aspx).
    	// However, testing revealed it does not always return a useful value. The GUID_DEVINTERFACE_USB_DEVICE value, defined as
    	// {A5DCBF10-6530-11D2-901F-00C04FB951ED}, has worked with cell phones, thumb drives, etc. For more info, see e.g.
    	// http://msdn.microsoft.com/en-us/library/windows/hardware/ff553426%28v=vs.85%29.aspx. 
    	DEFINE_GUID(GUID_DEVINTERFACE_USB_DEVICE, 0xA5DCBF10L, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED);
    	/// <summary>
        /// Declare a delegate for the notification event handler.
        /// </summary>
        /// <param name="sender">The object where the event handler is attached.</param>
        /// <param name="e">The event data.</param>
    	public delegate void NotificationEventHandler(Object^ sender, EventArgs^ e);
    	/// <summary>
        /// Class that generetaes USB Device Change notification events.
        /// </summary>
    	/// <remarks>
    	/// A Form is not necessary. Any type wherein you can override WndProc() can be used.
    	/// </remarks>
    	public ref class EventNotifier : public Control
    	{
    	private:
    		/// <summary>
            /// Raises the NotificationEvent.
            /// </summary>
            /// <param name="e">The event data.</param>
    		void RaiseNotificationEvent(EventArgs^ e) {
    			NotificationEvent(this, e);
    		}
    	protected:
    		/// <summary>
    		/// Overrides the base class WndProc method.
    		/// </summary>
    		/// <param name="message">The Windows Message to process. </param>
    		/// <remarks>
    		/// This method receives Windows Messages (WM_xxxxxxxxxx) and
    		/// raises our NotificationEvent as appropriate. Here you should
    		/// add any message filtering (e.g. for the WM_DEVICECHANGE) and
    		/// preprocessing before raising the event (or not).
    		/// </remarks>
    		virtual void WndProc(Message% message) override {
    			if(message.Msg == WM_DEVICECHANGE)
    			{
    				RaiseNotificationEvent(EventArgs::Empty);
    			}
    			__super::WndProc(message);
    		}
    	public:
    		/// <summary>
    		/// Creates a new instance of the EventNotifier class.
    		/// </summary>
    		EventNotifier(void) {
    			RequestNotifications(this->Handle);	// Register ourselves as the Windows Message processor.
    		}
    		/// <summary>
            /// Registers an object, identified by the handle, for
            /// Windows WM_DEVICECHANGE messages.
    		/// </summary>
    		/// <param name="handle">The object's handle.</param>
    		bool RequestNotifications(IntPtr handle) {
    			DEV_BROADCAST_DEVICEINTERFACE NotificationFilter;
                ZeroMemory(&NotificationFilter, sizeof(NotificationFilter));
    			NotificationFilter.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
    			NotificationFilter.dbcc_size = sizeof(DEV_BROADCAST_DEVICEINTERFACE);
    			NotificationFilter.dbcc_reserved = 0;
    			NotificationFilter.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE;
    			return RegisterDeviceNotificationUM((HANDLE)handle, &NotificationFilter, DEVICE_NOTIFY_WINDOW_HANDLE) != NULL;
    		}
    		/// <summary>
            /// Defines the notification event.
            /// </summary>
    		virtual event NotificationEventHandler^ NotificationEvent;
    	};
    }
