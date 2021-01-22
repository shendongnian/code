    public class MyBusinessCardPresenter
    {
        private IMyBusinessCardView _view;
        private MyBusinessCard _myCard;
        public void ViewClickedSave()
        {
            //You can have all your business logic here which is easy to unit test.
            var businessCard = new BusinessCard()
            {
                Field1 = view.Field1
            };
            _myCard.SaveNewBusinessCard(businessCard);
        }
        public void LoadView()
        {
            view.Field1 = _myCard.LoadMyBusinessCardToView().Field1;
        }
    }
    public class MyBusinessCard
    {
        public void SaveNewBusinessCard(BusinessCard businessCard)
        {
            using (var context = new DataContext())
            {
                context.BusinessCards.InsertOnSubmit(card);
                context.SubmitChanges();
            }
        }
        public BusinessCard LoadMyBusinessCardToView()
        {
            // Query using Linq to Sql and set in view
            return card;
        }
    }
