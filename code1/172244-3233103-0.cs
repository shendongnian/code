        using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Windows.Forms;
    namespace Akadia
    {
        namespace SubmitButton
        {
            // User Control which contain a text box for your
            // name and a button that will fire an event.
            public class SubmitButtonControl : System.Windows.Forms.UserControl
            {
                private System.Windows.Forms.TextBox txtName;
                private System.Windows.Forms.Label lblName;
                private System.Windows.Forms.Button btnSubmit;
                private System.ComponentModel.Container components = null;
                // Declare delegate for submit button clicked.
                //
                // Most action events (like the Click event) in Windows Forms
                // use the EventHandler delegate and the EventArgs arguments.
                // We will define our own delegate that does not specify parameters.
                // Mostly, we really don't care what the conditions of the
                // click event for the Submit button were, we just care that
                // the Submit button was clicked.
                public delegate void SubmitClickedHandler();
                // Constructor           public SubmitButtonControl()
                {
                    // Create visual controls
                    InitializeComponent();
                }
                // Clean up any resources being used.
                protected override void Dispose( bool disposing )
                {
                    if( disposing )
                    {
                        if( components != null )
                            components.Dispose();
                    }
                    base.Dispose( disposing );
                }
                .....
                .....
                // Declare the event, which is associated with our
                // delegate SubmitClickedHandler(). Add some attributes
                // for the Visual C# control property.
                [Category("Action")]
                [Description("Fires when the Submit button is clicked.")]
                public event SubmitClickedHandler SubmitClicked;
                // Add a protected method called OnSubmitClicked().
                // You may use this in child classes instead of adding
                // event handlers.
                protected virtual void OnSubmitClicked()
                {
                    // If an event has no subscribers registerd, it will
                    // evaluate to null. The test checks that the value is not
                    // null, ensuring that there are subsribers before
                    // calling the event itself.
                    if (SubmitClicked != null)
                    {
                        SubmitClicked();  // Notify Subscribers
                    }
                }
                // Handler for Submit Button. Do some validation before
                // calling the event.
                private void btnSubmit_Click(object sender, System.EventArgs e)
                {
                    if (txtName.Text.Length == 0)
                    {
                        MessageBox.Show("Please enter your name.");
                    }
                    else
                    {
                        OnSubmitClicked();
                    }
                }
                // Read / Write Property for the User Name. This Property
                // will be visible in the containing application.
                [Category("Appearance")]
                [Description("Gets or sets the name in the text box")]
                public string UserName
                {
                    get { return txtName.Text; }
                    set { txtName.Text = value; }
                }
            }
        }
    }
