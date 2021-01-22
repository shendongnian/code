    using System.ComponentModel;
    using System;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form { Controls = {new PropertyGrid {
                Dock = DockStyle.Fill, SelectedObject = new Bar()
            }}});
        }
    }
    public class Foo
    {
        public virtual string A { get; set; }
        public virtual string B { get; set; }
        public virtual string C { get; set; }
        [Browsable(false)] public virtual string D { get; set; }
        [Browsable(false)] public virtual string E { get; set; }
        [Browsable(false)] public virtual string F { get; set; }
        [Browsable(true)] public virtual string G { get; set; }
        [Browsable(true)] public virtual string H { get; set; }
        [Browsable(true)] public virtual string I { get; set; }
    }
    public class Bar : Foo
    {
        public override string A { get { return base.A; } set { base.A = value; } }
        [Browsable(false)] public override string B { get { return base.B; } set { base.B = value; } }
        [Browsable(true)] public override string C { get { return base.C; } set { base.C = value; } }
        public override string D { get { return base.D; } set { base.D = value; } }
        [Browsable(false)] public override string E { get { return base.E; } set { base.E = value; } }
        [Browsable(true)] public override string F { get { return base.F; } set { base.F = value; } }
        public override string G { get { return base.G; } set { base.G = value; } }
        [Browsable(false)] public override string H { get { return base.H; } set { base.H = value; } }
        [Browsable(true)] public override string I { get { return base.I; } set { base.I = value; } }
    }
