cs
public void M(Guid guid)
{
    if (guid == null) throw new ArgumentNullException();
}
will be compiled to:
// Methods
    .method public hidebysig 
        instance void M (
            valuetype [mscorlib]System.Guid guid
        ) cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 1 (0x1)
        .maxstack 8
        IL_0000: ret
    } // end of method C::M
As you can see, the first instruction in the method is return.
