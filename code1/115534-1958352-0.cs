        public void GroupErrorsByErrorCode(List<MyError> errors)
        {
            errors.GroupBy(e => e.ErrorCode).Select(group => new MyError
                {
                    ErrorCode = group.Key,
                    Errors = group.SelectMany(g => g.Errors)
                });
        }
