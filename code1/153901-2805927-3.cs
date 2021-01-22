    Type objectType = testClass.GetType();                     
    MethodInfo members = objectType.GetMethod("setValues");
    ParameterInfo[] parameters = members.GetParameters();
    For( int t = 0; t < parameters.Length; t++)
    {
      If (parameters[t]. ParameterType ==  typeof())
      {
        object value = this.textBox2.Text;                          
        parameters.SetValue(Convert.ChangeType(value,parameters[t].ParameterType), t);
      }
    }
                                  
