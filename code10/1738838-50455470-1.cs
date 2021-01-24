	using System;
	using System.Windows.Forms;
	namespace DRT
	{
		internal abstract partial class DRT_ComboBox_Abstract : ComboBox
		{
			public DRT_ComboBox_Abstract()
			{
				InitializeComponent();
			}
			protected override void OnSelectedValueChanged(object sender, EventArgs args)
			{
				// Wait, the base class is attempting to notify the subscribers that Selected Value has Changed! Let me do something before that
				// This method is intercepting the event notification
				
				// Do stuff
				
				// Continue throwing the notification
				base.OnSelectedValueChanged(sender, args);
			}
		}
	}
