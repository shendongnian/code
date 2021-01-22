    public sealed class ContactInfo : Union<
                                         EmailAddress,
                                         PostalAddress,
                                         Typle<EmaiAddress,PostalAddress>
                                      >
    {
        public Contact(EmailAddress emailAddress) : base(emailAddress) { }
        public Contact(PostalAddress postalAddress) : base(postalAddress) { }
        public Contact(Typle<EmaiAddress, PostalAddress> emailAndPostalAddress) : base(emailAndPostalAddress) { }
    }
