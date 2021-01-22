    public sealed class ContactInfo : Union<
                                         EmailAddress,
                                         PostalAddress,
                                         Tuple<EmaiAddress,PostalAddress>
                                      >
    {
        public Contact(EmailAddress emailAddress) : base(emailAddress) { }
        public Contact(PostalAddress postalAddress) : base(postalAddress) { }
        public Contact(Tuple<EmaiAddress, PostalAddress> emailAndPostalAddress) : base(emailAndPostalAddress) { }
    }
