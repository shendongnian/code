public virtual List<AlternativeAddress> AlternativeAddresses { get; set; }
with
public virtual List<string> EmailAdresses { get; set; }
or
public virtual List<EmailEntity> EmailAdresses { get; set; }
both would be perfectly fine. It only depends on your likings and type of operations, you have to perform later on.
