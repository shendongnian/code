        public IQueryable<Location> SearchByLocationDistance(double latitude, double longitude, double rangeInKm)
        {         
            var rangeInMeters = rangeInKm * 1000;         
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude)); //long, lat
            var filter = Builders<Location>.Filter.Near(y => y.Address.GeoPoint, point, rangeInMeters);
            return collection.Find(filter).ToList().AsQueryable();
        }
