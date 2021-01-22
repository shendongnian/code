        /// <summary>
        /// There are no comments for Providers in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Client> Client
        {
            get
            {
                if ((this._Client== null))
                {
                    this._Client = base.CreateQuery<Client>("[Client]");
                }
                return this._Client;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Client> _Client;
