    public interface IAssociateTags {
      IEnumerable<Tag> GetTagFor(Contact contact);
      void TagContact(Contact contact, Tag tag);
      void UnTagContact(Contact contact, Tag tag);
    }
