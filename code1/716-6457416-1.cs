    public static object Eval(string sCSCode) {
    
      CSharpCodeProvider c = new CSharpCodeProvider();
      ICodeCompiler icc = c.CreateCompiler();
      CompilerParameters cp = new CompilerParameters();
    
      cp.ReferencedAssemblies.Add("system.dll");
      cp.ReferencedAssemblies.Add("system.xml.dll");
      cp.ReferencedAssemblies.Add("system.data.dll");
      cp.ReferencedAssemblies.Add("system.windows.forms.dll");
      cp.ReferencedAssemblies.Add("system.drawing.dll");
    
      cp.CompilerOptions = "/t:library";
      cp.GenerateInMemory = true;
    
      StringBuilder sb = new StringBuilder("");
      sb.Append("using System;\n" );
      sb.Append("using System.Xml;\n");
      sb.Append("using System.Data;\n");
      sb.Append("using System.Data.SqlClient;\n");
      sb.Append("using System.Windows.Forms;\n");
      sb.Append("using System.Drawing;\n");
    
      sb.Append("namespace CSCodeEvaler{ \n");
      sb.Append("public class CSCodeEvaler{ \n");
      sb.Append("public object EvalCode(){\n");
      sb.Append("return "+sCSCode+"; \n");
      sb.Append("} \n");
      sb.Append("} \n");
      sb.Append("}\n");
    
      CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
      if( cr.Errors.Count > 0 ){
          MessageBox.Show("ERROR: " + cr.Errors[0].ErrorText, 
             "Error evaluating cs code", MessageBoxButtons.OK, 
             MessageBoxIcon.Error );
          return null;
      }
    
      System.Reflection.Assembly a = cr.CompiledAssembly;
      object o = a.CreateInstance("CSCodeEvaler.CSCodeEvaler");
    
      Type t = o.GetType();
      MethodInfo mi = t.GetMethod("EvalCode");
    
      object s = mi.Invoke(o, null);
      return s;
    
    }
