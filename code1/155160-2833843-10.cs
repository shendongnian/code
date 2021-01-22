    IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
    {
        ScriptControlDescriptor desc = new ScriptControlDescriptor("Project.MyDateTimePicker", 
            this.ClientID);
    
        // Properties
        desc.AddProperty("timeHourFormat", this.TimeHourFormat);
        desc.AddProperty("timeFormat", this.TimeFormat);
    
        yield return desc;
    }
    
    IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
    {
        ScriptReference reference = new ScriptReference();
        reference.Assembly = Assembly.GetAssembly(typeof(MyDateTimePicker)).FullName;
        reference.Name = "Project.MyDateTimePicker.js";
        yield return reference;
    }
