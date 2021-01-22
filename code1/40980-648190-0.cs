<pre>
protected virtual void LoadFieldDataEditor(Control control, BaseDataType objData, string strFieldName)
{
    SomeType1 type1 = objData as SomeType1;
    if (type1 != null)
    {
         // use type1.field1 here!
    }
}
</pre>
