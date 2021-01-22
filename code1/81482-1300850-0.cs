    // Since bs2's DataSource type is a BindingSource, you
    // can cast it as such and query it's underlying data-type as well
    BindingSource bs2DataBindingSource = (BindingSource)bs2.DataSource;
    Type bs2DataBindingSourceType = bs2DataBindingSource.DataSource.GetType();
    Console.WriteLine(bs2DataBindingSourceType.Name);
