        [HttpDelete]
        public HttpResponseMessage DeleteCart(int id)
        {
            //not sure what it does?
            if (IsNetworkAvailable(0))
            {
        
                var del = db.Carts.First(e => e.Id == id);
                db.Carts.Remove(del);
                db.SaveChanges();
        
                return Request.CreateResponse(HttpStatusCode.OK, "Delete Successfully");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No Network");
            }
        }
