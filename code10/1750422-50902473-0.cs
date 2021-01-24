    public string SomePublicField = "Hello!";
    private void button1_Click(object sender, EventArgs e) {
        var csc = new CSharpCodeProvider();
        var parameters = new CompilerParameters(new[] {
            "mscorlib.dll",
            "System.Windows.Forms.dll",
            "System.dll",
            "System.Core.dll",
            "Microsoft.CSharp.dll",
        }, "foo.dll", true);
        parameters.GenerateExecutable = false;
        CompilerResults results = csc.CompileAssemblyFromSource(parameters,
        @"using System.Linq;
        using System.Windows.Forms;
        public class Sample {
            public void DoSomething (dynamic form) {
            var b = new Button();
            b.Text = form.Text;
            b.Click += (s,e)=>{MessageBox.Show(form.SomePublicField);};
            form.Controls.Add(b);
            }
        }");
        if (!results.Errors.HasErrors) {
            var t = results.CompiledAssembly.GetType("Sample");
            dynamic o = Activator.CreateInstance(t);
            o.DoSomething(this);
        }
        else {
            var errors = string.Join(Environment.NewLine,
                results.Errors.Cast<CompilerError>().Select(x => x.ErrorText));
            MessageBox.Show(errors);
        }
    }
