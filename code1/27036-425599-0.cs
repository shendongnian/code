    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using System.Web;
    using System.Web.UI.WebControls;
    
    
    namespace Web.Library.Controls.Commands
    {
        public class CommandCheckBox : System.Web.UI.WebControls.CheckBox
        {
            private static readonly object EventCommand = new object();
    
            public event CommandEventHandler Command
            {
                add
                {
                    Events.AddHandler(EventCommand, value);
                }
                remove
                {
                    Events.RemoveHandler(EventCommand, value);
                }
            }
    
            public string CommandName
            {
                get
                {
                    if (this.ViewState["CommandName"] == null)
                        return string.Empty;
    
                    return (string)this.ViewState["CommandName"];
                }
                set { this.ViewState["CommandName"] = value; }
            }
            
            public string CommandArgument
            {
                get
                {
                    if (this.ViewState["CommandArgument"] == null)
                        return string.Empty;
    
                    return (string)this.ViewState["CommandArgument"];
                }
                set { this.ViewState["CommandArgument"] = value; }
            }
    
            protected virtual void OnCommand(CommandEventArgs args)
            {
                CommandEventHandler commandEventHand = Events[EventCommand] as CommandEventHandler;
    
                if (commandEventHand != null)
                {
                    commandEventHand(this, args);
                }
    
                base.RaiseBubbleEvent(this, args);
            }
                    
            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
    
                CommandEventArgs args = new CommandEventArgs(this.CommandName, this.CommandArgument);
    
                this.OnCommand(args);
            }
            
            
            public CommandCheckBox()
            {
            }
            
        }
    }
