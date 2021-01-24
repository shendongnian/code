    public Command<EventArgs> OpenNewZone
        {
            get
            {
                return new Command<EventArgs>(async e =>
                {
                    ZoneOpen = true;
                    PointCount = 0;
                    ActiveZonePositions.Clear();
                    Zone ZoneToAdd = new Zone
                    {
                        Contactsys = MobileUser.ContactSys,
                        ZoneTypesSys = 1,
                        OrganizationSys = MobileUser.OrganizationSys,
                        ZoneName = ""
                    };
                    ActiveZoneID = await AddZoneToDBAsync(ZoneToAdd);
                    ZoneToAdd.ID = ActiveZoneID;
                    ZoneToAdd.ZoneSys = ActiveZoneID;
                    await AddZoneToDBAsync(ZoneToAdd);
                });
            }
        }
