    ContentType ctype = ....;//your content type object
    String serialized_form = ctype.ToString();
    //save the string to whatever medium you like
    ...
    ContentType ctype2 = new ContentType(serialized_form);
    Debug.Assert(ctype.Equals(ctype2));
