    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    
    class ControlContainer : IContainer
    {
        ComponentCollection _components;
        
        public ControlContainer()
        {
            _components = new ComponentCollection(new IComponent[] { });
        }
        public void Add(IComponent component) { }
        public void Add(IComponent component, string Name) { }
        public void Remove(IComponent component) { }
        public ComponentCollection Components
        {
            get { return _components; }
        }
        public void Dispose()
        {
            _components = null;
        }
    }
    class MainEntryClass
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();
            Application.Run();
        }
    }
    class SomeClass
    {
        ControlContainer container = new ControlContainer();
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        public SomeClass()
        {
            this.notifyIcon1 = new NotifyIcon(container);
        }
    }
