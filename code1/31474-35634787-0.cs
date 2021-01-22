    // from caller:
    ListTasks(prj.OutlineChildren, "");
    void ListTasks(Tasks lst, string indent)
    {
        foreach (Microsoft.Office.Interop.MSProject.Task t in lst) {
            Log(indent + t.Start + " - " + t.Name);
            ListTasks(t.OutlineChildren, indent + "    ");
        }
    }
