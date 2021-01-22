    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace DesignerHost
    {
        class MenuCommandServiceImpl : MenuCommandService
        {
            DesignerVerbCollection m_globalVerbs = new DesignerVerbCollection();
    
            public MenuCommandServiceImpl(IServiceProvider serviceProvider)
                : base(serviceProvider)
            {
                m_globalVerbs.Add(StandartVerb("Cut", StandardCommands.Cut));
                m_globalVerbs.Add(StandartVerb("Copy", StandardCommands.Copy));
                m_globalVerbs.Add(StandartVerb("Paste", StandardCommands.Paste));
                m_globalVerbs.Add(StandartVerb("Delete", StandardCommands.Delete));
                m_globalVerbs.Add(StandartVerb("Select All", StandardCommands.SelectAll));
    
            }
    
            private DesignerVerb StandartVerb(string text, CommandID commandID)
            {
                return new DesignerVerb(text,
                    delegate(object o, EventArgs e) 
                    {
                        IMenuCommandService ms = 
                            GetService(typeof(IMenuCommandService)) as IMenuCommandService;
                        Debug.Assert(ms != null);
                        ms.GlobalInvoke(commandID); 
                    }
                );
            }
    
            class MenuItem : ToolStripMenuItem
            {
                DesignerVerb verb;
    
                public MenuItem(DesignerVerb verb)
                    : base(verb.Text)
                {
                    Enabled = verb.Enabled;
                    this.verb = verb;
                    Click += InvokeCommand;
                }
    
                void InvokeCommand(object sender, EventArgs e)
                {
                    try
                    {
                        verb.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Trace.Write("MenuCommandServiceImpl: " + ex.ToString());
                    }
                }
            }
    
            private ToolStripItem[] BuildMenuItems()
            {
                List<ToolStripItem> items = new List<ToolStripItem>();
    
                foreach (DesignerVerb verb in m_globalVerbs) 
                {
                    items.Add(new MenuItem(verb));
                }
                return items.ToArray();
            }
    
            #region IMenuCommandService Members
    
            /// This is called whenever the user right-clicks on a designer.
            public override void ShowContextMenu(CommandID menuID, int x, int y)
            {
                // Display our ContextMenu! Note that the coordinate parameters to this method
                // are in screen coordinates, so we've got to translate them into client coordinates.
    
                ContextMenuStrip cm = new ContextMenuStrip();
                cm.Items.AddRange(BuildMenuItems());
                
                ISelectionService ss = GetService(typeof (ISelectionService)) as ISelectionService;
                Debug.Assert(ss != null);
    
                Control ps = ss.PrimarySelection as Control;
                Debug.Assert(ps != null);
                
                Point s = ps.PointToScreen(new Point(0, 0));
                cm.Show(ps, new Point(x - s.X, y - s.Y));
            }
    
            #endregion
    
        }
    }
