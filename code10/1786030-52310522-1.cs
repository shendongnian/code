        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            GuestId = InitGuestCookie();
        }
