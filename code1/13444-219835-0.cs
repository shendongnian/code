    .field public string Foo // public field
    .property instance string Bar // public property
    {
        .get instance string MyType::get_Bar()
        .set instance void MyType::set_Bar(string)
    }
