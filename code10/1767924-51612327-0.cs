        public async Task<JsonResult> GetLatLong(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            Guid idGuid;
            Guid.TryParse(id, out idGuid);
            var flightData = await _context.FlightData.SingleOrDefaultAsync(m => m.ID == idGuid);
