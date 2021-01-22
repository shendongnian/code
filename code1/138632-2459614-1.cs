    CodeTypeReference ctr;
    if (/* you want to output this as nullable */)
    {
      ctr = new CodeTypeReference(typeof(Nullable<>));
      ctr.TypeArguments.Add(new CodeTypeReference(typeName));
    }
    else
    {
      ctr = new CodeTypeReference(typeName);
    }
    string typeName = codeDomProvider.GetTypeOutput(ctr);
