    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel.Design;
    namespace MakeSmartTag
    {
        public enum Languages
        {
            English,
            Arabic,
            Japanese
        }
        [Designer(typeof(UserControlDesigner))]
        public partial class UserControl2 : UserControl
        {
            public UserControl2()
            {
                InitializeComponent();
            }
            private Languages _language;
            public Languages Language
            {
                get { return _language; }
                set
                {
                    switch (value)
                    {
                        case Languages.Arabic:
                            {
                                label1.Text = "مرحباً";
                                _language = value;
                            }
                            break;
                        case Languages.English:
                            {
                                label1.Text = "Hello";
                                _language = value;
                            }
                            break;
                        case Languages.Japanese:
                            {
                                label1.Text = "Conechoa";
                                _language = value;
                            }
                            break;
                    }
                }
            }
        }
        public class UserControlDesigner : System.Windows.Forms.Design.ControlDesigner
        {
            private DesignerActionListCollection lists;
            public override DesignerActionListCollection ActionLists
            {
                get
                {
                    if (lists == null)
                    {
                        lists = new DesignerActionListCollection();
                        lists.Add(new UserControlActioonList(this.Component));
                    }
                    return lists;
                }
            }
        }
        public class UserControlActioonList : DesignerActionList
        {
            private UserControl2 myUserControl;
            private DesignerActionUIService designerActionSvc = null;
            public UserControlActioonList(IComponent component)
                : base(component)
            {
                this.myUserControl = (UserControl2)component;
                this.designerActionSvc =
                  (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
            }
            private PropertyDescriptor GetPropertyByName(string propName)
            {
                PropertyDescriptor prop = default(PropertyDescriptor);
                prop = TypeDescriptor.GetProperties(myUserControl)[propName];
                if (prop == null)
                {
                    throw new ArgumentException("Invalid Property", propName);
                }
                else
                {
                    return prop;
                }
            }
            public override System.ComponentModel.Design.DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection item = new DesignerActionItemCollection();
                item.Add(new DesignerActionHeaderItem(
                           "المظهر"));
                item.Add(new DesignerActionPropertyItem(
                           "BackColor", "لون الخلفية", "Appearance", "Set background Color of the control"));
                item.Add(new DesignerActionHeaderItem("تحديد اللغة"));
                item.Add(new DesignerActionPropertyItem(
                           "Language", "اللغة", "Functions", "Set the language of the control"));
                return item;
            }
            public Color BackColor
            {
                get { return this.myUserControl.BackColor; }
                set { GetPropertyByName("BackColor").SetValue(myUserControl, value); }
            }
            public Languages Language
            {
                get { return this.myUserControl.Language; }
                set { GetPropertyByName("Language").SetValue(myUserControl, value); }
            }
        }
    }
