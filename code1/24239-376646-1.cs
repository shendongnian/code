    using System.Reflection;
    using System.Web.Compilation;
    
    Page p = BuildManager.CreateInstanceFromVirtualPath("~/mypage.aspx", typeof(Page)) as Page;
    MethodInfo MyMethod = p.GetType().GetMethod("MyMethod");
    MyMethod.Invoke(p, null);
