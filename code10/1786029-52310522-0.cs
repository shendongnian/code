        public Guid InitGuestCookie()
        {
            if (Request.Cookies.AllKeys.Contains(Utils.Constants.GuestId))
            {
                var id = Request.Cookies[Utils.Constants.GuestId];
                if (id != null)
                {
                    var guid = new Guid(id.Value);
                    // Make sure this guid exists as a registered guest
                    var guest = _guestService.GetById(guid);
                    if (guest != null)
                    {
                        return guest.Id;
                    }
                }
            }
            var newGuest = CreateGuest();
            var cookie = new HttpCookie(Utils.Constants.GuestId, newGuest.Id.ToString());
            Response.Cookies.Set(cookie);
            return newGuest.Id;
        }
        public Guid GuestId { get; set; }
        public Guest CreateGuest()
        {
            var guid = Guid.NewGuid();
            var newGuest = new Guest()
            {
                CreateDate = DateTime.Now,
                LastUsageDate = DateTime.Now,
                Id = guid,
            };
            _guestService.AddOrUpdate(newGuest);
            return newGuest;
        }
