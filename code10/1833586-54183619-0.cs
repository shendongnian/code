int i = 0; // Place it here instead
private void Button1_Click(object sender, EventArgs e)
{
    // Assign i here like you did
    i = r.Next();
}
private void Button2_Click(object sender, EventArgs e)
{
    // i is usable here now!
}
The reason it wasn't accessible in your example is that each method is in a different scope. Variables declared in one scope are "invisible" to another scope. So variables you declare inside MethodA() are invisible to MethodB().  
