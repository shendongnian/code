    using System.Reflection;
    if (c.GetType().GetProperty("MyCustomProperty") != null)
    {
      string something = ((dynamic)c).MyCustomProperty; //Assuming your property is a string
    }
