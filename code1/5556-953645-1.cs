    public class UserDaoHibernateImpl extends GenericDaoHibernateImpl<User> {
        public UserDaoHibernateImpl() {
            super(User.class);     // This is for giving Hibernate a .class
                                   // work with, as generics disappear at runtime
        }
        // Entity specific methods here
    }
