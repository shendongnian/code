    public class AuthorizationService
    {
        ...
        public Task<bool> IsAuthorizedAsync(Item item)
        {
            var authorized = item != null 
                                && item.Status != ItemStatus.Closed 
                                && item.Owner == _currentUser 
                                && (!(_currentUser is Manager) && editedItem.Status == item.Status.Open);
            return Task.FromResult(authorized);
        }
    }
