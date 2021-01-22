    <Serializable> Public Class MyClass
        Public Property Children as List(of ChildCLass)
        <XmlAttribute> Public Property MyFirstProperty as string
        <XmlAttribute> Public Property MySecondProperty as string
    End Class
    <Serializable> Public Class ChildClass
        <XmlAttribute> Public Property MyFirstProperty as string
        <XmlAttribute> Public Property MySecondProperty as string
    End Class
