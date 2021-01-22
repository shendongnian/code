    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using System.Collections;
    
    static class Program
    {
        static void Main()
        {
            MyWrapper wrapper = new MyWrapper();
            wrapper.Modules.Add(new ModuleData { ModuleId = 123 });
            wrapper.Modules.Add(new ModuleData { ModuleId = 456 });
            wrapper.Modules.Add(new ModuleData { ModuleId = 789 });
    
            wrapper.Batches.Add(new BatchData(wrapper) { BatchId = 666 });
            wrapper.Batches.Add(new BatchData(wrapper) { BatchId = 777 });
    
            PropertyGrid props = new PropertyGrid { Dock = DockStyle.Fill };
            ListView view = new ListView { Dock = DockStyle.Left };
            foreach (ModuleData mod in wrapper.Modules) {
                view.Items.Add(mod.ToString()).Tag = mod;
            }
            foreach (BatchData bat in wrapper.Batches) {
                view.Items.Add(bat.ToString()).Tag = bat;
            }
            view.SelectedIndexChanged += delegate {
                var sel = view.SelectedIndices;
                if(sel.Count > 0) {
                    props.SelectedObject = view.Items[sel[0]].Tag;
                }
            };
    
            Application.Run(new Form { Controls = { props, view} });
        }
    }
    
    class MyWrapper
    {
        private List<ModuleData> modules = new List<ModuleData>();
        public List<ModuleData> Modules { get { return modules; } }
    
        private List<BatchData> batches = new List<BatchData>();
        public List<BatchData> Batches { get { return batches; } }
    }
    
    class ModuleListEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
     	     return UITypeEditorEditStyle.DropDown;
        }
        public override object  EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc;
            IHasModules mods;
            IList selectedModules;
            if (context == null || (selectedModules = (IList)value) == null ||
                (mods = context.Instance as IHasModules) == null
                || (svc = (IWindowsFormsEditorService)
                provider.GetService(typeof(IWindowsFormsEditorService))) == null)
            {
                return value;
            }
            var available = mods.GetAvailableModules();
            CheckedListBox chk = new CheckedListBox();
            foreach(object item in available) {
                bool selected = selectedModules.Contains(item);
                chk.Items.Add(item, selected);
            }
            chk.ItemCheck += (s, a) =>
            {
                switch(a.NewValue) {
                    case CheckState.Checked:
                        selectedModules.Add(chk.Items[a.Index]);
                        break;
                    case CheckState.Unchecked:
                        selectedModules.Remove(chk.Items[a.Index]);
                        break;
                }
            };
    
    
            svc.DropDownControl(chk);
    
            return value;
        }
        public override bool IsDropDownResizable {
            get {
                return true;
            }
        }
    }
    
    
    interface IHasModules
    {
        ModuleData[] GetAvailableModules();
    }
    
    internal class BatchData : IHasModules {
        private MyWrapper wrapper;
        public BatchData(MyWrapper wrapper) {
            this.wrapper = wrapper;
        }
        ModuleData[] IHasModules.GetAvailableModules() { return wrapper.Modules.ToArray(); }
        [DisplayName("Batch ID")]
        public int BatchId { get; set; }
        private List<ModuleData> modules = new List<ModuleData>();
        [Editor(typeof(ModuleListEditor), typeof(UITypeEditor))]
        public List<ModuleData> Modules { get { return modules; } set { modules = value; } }
    
        public override string ToString() {
            return "Batch " + BatchId;
        }
    }
    
    internal class ModuleData {
        [DisplayName("Module ID")]
        public int ModuleId { get; set; }
    
        public override string ToString() {
            return "Module " + ModuleId;
        }
    }
