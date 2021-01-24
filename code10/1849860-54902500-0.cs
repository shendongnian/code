    Imports Microsoft.Win32
    Imports System.Security
    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides a mechanism to prevent any system shutdown/restart/log-off request during the life-cycle of a instance of this class.
    ''' <para></para>
    ''' Applications should use this class as they begin an operation that cannot be interrupted, such as burning a CD or DVD.
    ''' <para></para>
    ''' This class is to be used in either a <see langword="Using"/> statement or for the life-cycle of the current application.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <remarks>
    ''' Original source-code: <see href="https://github.com/dahall/Vanara/blob/master/WIndows.Forms/Contexts/PreventShutdownContext.cs"/>
    ''' </remarks>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code lang="vb">
    ''' Using psc As New PreventShutdownContext("Critical operation is in progress...")
    '''     ' Do something that can't be interrupted... 
    ''' End Using
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example.
    ''' <code lang="vb">
    ''' Public NotInheritable Class Form1 : Inherits Form
    ''' 
    '''     Private psc As PreventShutdownContext
    ''' 
    '''     Private Sub AllowShutdown()
    '''         If (Me.psc IsNot Nothing) Then
    '''             Me.psc.Dispose()
    '''             Me.psc = Nothing
    '''         End If
    '''     End Sub
    ''' 
    '''     Private Sub DisallowShutdown()
    '''         If (Me.psc Is Nothing) Then
    '''             Me.psc = New PreventShutdownContext("Application defined reason goes here.")
    '''         End If
    '''     End Sub
    ''' 
    '''     Protected Overrides Sub OnShown(ByVal e As EventArgs)
    '''         Me.DisallowShutdown()
    '''         MyBase.OnShown(e)
    '''     End Sub
    ''' 
    ''' End Class
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <example> This is a code example using the <see langword="using"/> statement.
    ''' <code lang="cs">
    ''' using (new PreventShutdownContext("Critical operation is in progress...")) {
    '''    // Do something that can't be interrupted...
    ''' }
    ''' </code>
    ''' </example>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <code lang="cs">
    ''' public partial class Form1 : Form {
    ''' 
    '''    private PreventShutdownContext disallowShutdown;
    ''' 
    '''	   private void AllowShutdown() {
    '''		   if (this.psc != null) {
    '''			   this.psc.Dispose();
    '''			   this.psc = null;
    '''		   }
    '''	   }
    '''
    '''	   private void DisallowShutdown() {
    '''		   if (this.psc == null) {
    '''			   this.psc = new PreventShutdownContext("Application defined reason goes here.");
    '''		   }
    '''	   }
    '''
    '''	   protected override void OnShown(EventArgs e) {
    '''		   this.DisallowShutdown();
    '''		   base.OnShown(e);
    '''	   }
    '''	   
    ''' }
    ''' </code>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class PreventShutdownContext : Implements IDisposable
    #Region " Private Fields "
        ''' <summary>
        ''' Holds the main window handle for the current application.
        ''' </summary>
        Private ReadOnly hRef As HandleRef
        ''' <summary>
        ''' Flag to determine whether the shutdown reason is created.
        ''' </summary>
        Private isReasonCreated As Boolean
        ''' <summary>
        ''' Holds the previous value of "HKEY_USERS\.DEFAULT\Control Panel\Desktop" "AutoEndTasks" registry value.
        ''' <para></para>
        ''' This registry value is restored when calling <see cref="PreventShutdownContext.Dispose()"/>
        ''' </summary>
        Private ReadOnly previousAutoEndTasksValue As Boolean
    #End Region
    #Region " Constructors "
        ''' <summary>
        ''' Initializes a new instance of the <see cref="PreventShutdownContext"/> class.
        ''' </summary>
        ''' <param name="reason">
        ''' The reason for which the current application must prevent system shutdown. 
        ''' <para></para>
        ''' Because users are typically in a hurry when shutting down the system, 
        ''' they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. 
        ''' Therefore, it is important that your reason strings are short and clear.
        ''' </param>
        ''' 
        ''' <param name="throwOnError">
        ''' If <see langword="True"/>, the method will throw an exception 
        ''' if the application does not meet the requirements to prevent system shutdown.
        ''' <para></para>
        ''' Default value is <see langword="True"/>.
        ''' </param>
        ''' <exception cref="InvalidOperationException">
        ''' Applications without a user interface can't prevent system shutdown.
        ''' </exception>
        ''' 
        ''' <exception cref="InvalidOperationException">
        ''' The main window of the current application is not yet created or is not visible.
        ''' </exception>
        ''' 
        ''' <exception cref="InvalidOperationException">
        ''' Only the thread that created the main window of the current application can prevent system shutdown.
        ''' </exception>
        ''' 
        ''' <exception cref="SecurityException">
        ''' The user does not have the permissions required to create or modify 'AutoEndTasks' registry value. 
        ''' Therefore, the application can't prevent system shutdown.
        ''' </exception>
        <DebuggerStepThrough>
        Public Sub New(ByVal reason As String, Optional ByVal throwOnError As Boolean = True)
            If Not Environment.UserInteractive Then
                If (throwOnError) Then
                    Throw New InvalidOperationException(
                        "Applications without a user interface can't prevent system shutdown.")
                End If
            End If
            Dim pr As Process = Process.GetCurrentProcess()
            Me.hRef = New HandleRef(pr, pr.MainWindowHandle)
            If (Me.hRef.Handle = IntPtr.Zero) Then
                If (throwOnError) Then
                    Throw New InvalidOperationException(
                        "The main window of the current application is not yet created or is not visible.")
                End If
            End If
            Dim currentThreadId As UInteger = NativeMethods.GetCurrentThreadId()
            Dim mainThreadId As Integer = NativeMethods.GetWindowThreadProcessId(Me.hRef.Handle, Nothing)
            If (currentThreadId <> mainThreadId) Then
                If Not Environment.UserInteractive Then
                    Throw New InvalidOperationException(
                        "Only the thread that created the main window of the current application can prevent system shutdown.")
                End If
            End If
            Me.previousAutoEndTasksValue = TweakingUtil.AutoEndTasks
            If (Me.previousAutoEndTasksValue) Then
                Try
                    TweakingUtil.AutoEndTasks = False
                Catch ex As SecurityException
                    If (throwOnError) Then
                        Throw New SecurityException(
                                "The user does not have the permissions required to create or modify 'AutoEndTasks' registry value. " &
                                "Therefore, the application can't prevent system shutdown.", ex)
                    End If
                Catch ex As Exception
                    If (throwOnError) Then
                        Throw
                    End If
                End Try
            End If
            AddHandler SystemEvents.SessionEnding, AddressOf Me.SessionEnding
            Me.Reason = reason
        End Sub
    #End Region
    #Region " Properties "
        ''' <summary>
        ''' Gets or sets the reason for which the current application must prevent system shutdown. 
        ''' <para></para>
        ''' Because users are typically in a hurry when shutting down the system, 
        ''' they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. 
        ''' Therefore, it is important that your reason strings are short and clear.
        ''' </summary>
        ''' <value>
        ''' The reason for which the current application must prevent system shutdown.
        ''' </value>
        Public Property Reason As String
            Get
                Return Me.reason_
            End Get
            <DebuggerStepThrough>
            Set(ByVal value As String)
                If value.Equals(Me.reason_, StringComparison.Ordinal) Then
                    Exit Property
                End If
                Me.SetReason(value)
                Me.reason_ = value
            End Set
        End Property
        ''' <summary>
        ''' ( backing field of <see cref="PreventShutdownContext.Reason"/> property )
        ''' <para></para>
        ''' The reason for which the application must prevent system shutdown.
        ''' </summary>
        Private reason_ As String
    #End Region
    #Region " Event-Handlers "
        ''' <summary>
        ''' Handles the <see cref="Microsoft.Win32.SystemEvents.SessionEnding"/> event.
        ''' </summary>
        ''' <param name="sender">
        ''' The source of the event.
        ''' </param>
        ''' 
        ''' <param name="e">
        ''' The <see cref="SessionEndingEventArgs"/> instance containing the event data.
        ''' </param>
        Private Sub SessionEnding(ByVal sender As Object, e As SessionEndingEventArgs)
            ' By setting "e.Cancel" property to True, 
            ' the application will respond 0 (zero) to "WM_QUERYENDSESSION" message in order to prevent a system shutdown. 
            '
            ' For more info: 
            ' https://docs.microsoft.com/en-us/windows/desktop/shutdown/wm-queryendsession
            ' https://docs.microsoft.com/en-us/windows/desktop/Shutdown/shutdown-changes-for-windows-vista
            e.Cancel = True
        End Sub
    #End Region
    #Region " Private Methods "
        ''' <summary>
        ''' Sets the reason for which the current application must prevent system shutdown.
        ''' </summary>
        ''' <param name="reason">
        ''' The reason for which the current application must prevent system shutdown.
        ''' <para></para>
        ''' Because users are typically in a hurry when shutting down the system, 
        ''' they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. 
        ''' Therefore, it is important that your reason strings are short and clear.
        ''' </param>
        ''' <exception cref="Win32Exception">
        ''' </exception>
        <DebuggerStepThrough>
        Private Sub SetReason(ByVal reason As String)
            Dim succeed As Boolean
            Dim win32Err As Integer
            If (Me.isReasonCreated) Then
                succeed = NativeMethods.ShutdownBlockReasonDestroy(Me.hRef.Handle)
                win32Err = Marshal.GetLastWin32Error()
                If Not succeed Then
                    Throw New Win32Exception(win32Err)
                End If
            End If
            succeed = NativeMethods.ShutdownBlockReasonCreate(Me.hRef.Handle, reason)
            win32Err = Marshal.GetLastWin32Error()
            If Not succeed Then
                Throw New Win32Exception(win32Err)
            End If
            Me.isReasonCreated = True
        End Sub
    #End Region
    #Region " IDisposable Implementation "
        ''' <summary>
        ''' Flag to detect redundant calls when disposing.
        ''' </summary>
        Private isDisposed As Boolean
        ''' <summary>
        ''' Releases all the resources used by this instance.
        ''' </summary>
        <DebuggerStepThrough>
        Public Sub Dispose() Implements IDisposable.Dispose
            Me.Dispose(isDisposing:=True)
        End Sub
        ''' <summary>
        ''' Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        ''' Releases unmanaged and, optionally, managed resources.
        ''' </summary>
        ''' <param name="isDisposing">
        ''' <see langword="True"/>  to release both managed and unmanaged resources; 
        ''' <see langword="False"/> to release only unmanaged resources.
        ''' </param>
        <DebuggerStepThrough>
        Private Sub Dispose(ByVal isDisposing As Boolean)
            If (Not Me.isDisposed) AndAlso (isDisposing) Then
                RemoveHandler SystemEvents.SessionEnding, AddressOf Me.SessionEnding
                NativeMethods.ShutdownBlockReasonDestroy(Me.hRef.Handle)
                Me.isReasonCreated = False
                Try
                    TweakingUtil.AutoEndTasks = Me.previousAutoEndTasksValue
                Catch
                End Try
            End If
            Me.isDisposed = True
        End Sub
    #End Region
    End Class
