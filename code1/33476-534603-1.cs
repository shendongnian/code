internal static List&lt;Control&gt; GetAllChildControls(Control topControl)
{
    List&lt;Control&gt; ctrlStore = new List&lt;Control&gt;();
    ctrlStore.Add(topControl);
    if (topControl.HasChildren)
    {
        foreach (Control ctrl in topControl.Controls)
        {
            ctrlStore.AddRange(GetAllChildControls(ctrl));                }
        }
    }
    return ctrlStore;
}
</pre>
