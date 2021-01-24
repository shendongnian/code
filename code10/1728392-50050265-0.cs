    public void updateAvg(List<Restaurante> restaurantes)
        {
            using (WebMVCContext db = new WebMVCContext())
            {
                foreach (var item in restaurantes)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
        }
