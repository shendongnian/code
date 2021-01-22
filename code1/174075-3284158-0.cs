    namespace WindowsFormsApplication5
    {
        using System;
        using System.Threading;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            TextBox OutPutTextBox = new TextBox();
    
            /// <summary>
            /// Represents Send Mail information.
            /// </summary>
            class MailInfo
            {
                public string from;
                public string password;
                public string to;
                public string subject;
                public string body;
            }
    
            void ProcessToDoList( string[] toList )
            {
                foreach ( var to in toList )
                {
                    MailInfo info = new MailInfo();
                    info.from = "xx"; //TODO.
                    info.password = "yy"; //TODO.
                    info.to = "zz"; //TODO.
                    info.subject = "aa"; //TODO.
                    info.body = "bb"; //TODO.
                    ThreadPool.QueueUserWorkItem( this.SendMail, info );
                }
            }
    
            /// <summary>
            /// Send mail.
            /// NOTE: this occurs on a separate, non-UI thread.
            /// </summary>
            /// <param name="o">Send mail information.</param>
            void SendMail( object o )
            {
                MailInfo info = ( MailInfo )o;
                bool hasSent = false;
    
                //TODO: put your SendMail implementation here. Set hasSent field.
                //
    
                // Now test result and append text.
                //
    
                if ( hasSent )
                {
                    this.AppendText( "Sent to: " + info.to );
                }
                else
                {
                    this.AppendText( "Failed to: " + info.to );
                }
            }
    
            /// <summary>
            /// Appends the specified text to the TextBox control.
            /// NOTE: this can be called from any thread.
            /// </summary>
            /// <param name="text">The text to append.</param>
            void AppendText( string text )
            {
                if ( this.InvokeRequired )
                {
                    this.BeginInvoke( ( Action )delegate { this.AppendText( text ); } ); 
                    return;
                }
    
                OutPutTextBox.AppendText( text );
            }
        }
    }
