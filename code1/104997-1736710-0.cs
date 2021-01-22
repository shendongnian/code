    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    // note : compiles against FrameWork 2.0 and 4.0
    // wanted this to work w/o Linq, automatic properties, etc.
    
    namespace MessageHandler
    {
        public static class TextBoxMessenger
        {
            // internal List of TextBoxes of interest on all Forms
            internal static List<TextBox> _messageEnabledTBxes = new List<TextBox>();
    
            // public Property to get/set the collection of TextBoxes of interest
            public static List<TextBox>MessageEnabledTextBoxes
            {
                get { return _messageEnabledTBxes; }
    
                set { _messageEnabledTBxes = value; }
            }
    
            // in case you want to register one TextBox at a time
            public static void RegisterTextBoxForMessaging(TextBox theTBx)
            {
                _messageEnabledTBxes.Add(theTBx);
            }
    
           // send from one specific TBx to another
            public static void setText(TextBox originTBx, TextBox destinationTBx)
           {
               destinationTBx.Text = originTBx.Text;
           }
    
           // send to a specified list of TextBoxes
            public static void setText(TextBox originTBx, List<TextBox> destinationTBxs)
           {
               foreach (TextBox theTBx in destinationTBxs)
               {
                   theTBx.Text = originTBx.Text;
               }
           }
    
            // set text in all other TextBoxes in MessageEnabledTextBoxes list
            public static void setText(TextBox originTBx)
           {
               foreach (TextBox theTBx in _messageEnabledTBxes)
               {
                   // a needless check, since assigning the text of the
                   // original TextBox to itself wouldn't "hurt" anything
                   // but, imho, much better "practice" to always test
                   if (theTBx != originTBx) theTBx.Text = originTBx.Text;
               }
           }
        }
    }
