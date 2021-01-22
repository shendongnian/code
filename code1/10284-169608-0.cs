    using System.Collections.ObjectModel;
    public class Foo
     { private Collection<FileInfo> files = new Collection<FileInfo>();
       public Collection<FileInfo> Files { get { return files;} }
     }
    //...
    Foo f = new Foo();
    f.Files.Add(file);
