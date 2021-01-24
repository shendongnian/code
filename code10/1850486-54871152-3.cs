            [HttpDelete]
            public HttpResponseMessage DeleteUserCarts(int userId)
            {
                //not sure what it does?
                if (IsNetworkAvailable(0))
                {
            
                    var carts = db.Carts.Where(e => e.UID == userId);
                    db.Carts.RemoveRange(carts);
                    db.SaveChanges();
            
                    return Request.CreateResponse(HttpStatusCode.OK, "Delete Successfully");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No Network");
                }
            }
