	using System;
	using System.Windows.Forms;
	namespace DRT
	{
		internal abstract partial class DRT_ComboBox_Abstract : ComboBox
		{
			public DRT_ComboBox_Abstract()
			{
				InitializeComponent();
				SelectedValueChanged += MyOwnHandler
			}
			protected virtual void MyOwnHandler(object sender, EventArgs args)
			{
				// Hmn.. now I know that the selection has changed and can so somethig from here
				// This method is acting like a simple client
			}
		}
	}
