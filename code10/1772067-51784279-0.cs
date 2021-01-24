    var serviceProvider1 = services.BuildServiceProvider();
    var hashCode1 = serviceProvider1.GetService<IAccessInfoStore>().GetHashCode();
    var hashCode2 = serviceProvider1.GetService<IAccessInfoStore>().GetHashCode();
    var serviceProvider2 = services.BuildServiceProvider();
    var hashCode3 = serviceProvider2.GetService<IAccessInfoStore>().GetHashCode();
    var hashCode4 = serviceProvider2.GetService<IAccessInfoStore>().GetHashCode();
