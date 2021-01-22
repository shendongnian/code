<pre>
private void button1_Click(object sender, EventArgs e)
{
    Person newStart = (Person)listBox1.SelectedItem;
    if (newStart != null)
    {
        PersonManager.Instance.StartPerson = newStart;
        newStart.Name = newStart.Name; // Dumb, but forces a PropertyChanged event so the binding updates
    }
}
</pre>
