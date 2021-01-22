    internal class DoNotCopyAttribute: Attribute{}
    
    // then add this to Odhran's GetMeTheProperties
    bool skip=false;
    foreach (System.Attribute attr in System.Attribute.GetCustomAttributes(sourceProperty)) {
      if (attr is DoNotCopyAttribute){ skip=true; break; }
    }
    if(skip) continue;
