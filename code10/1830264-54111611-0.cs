       [HttpGet]
        [AjaxOnly]
        public async Task<PartialViewResult> foodsearch(int o, string q, string filters)
        {
            //some local veriable declared
            model.foods = new List<Food>();
            if (filters.ToLower() == FoodFilterTypes.b_food
            || filters.ToLower() == all_categories)
            {
                var gotResult = false;
                var tokenSource1 = new CancellationTokenSource();
                var tokenSource2 = new CancellationTokenSource();
                CancellationToken ct1 = tokenSource.Token;
                CancellationToken ct2 = tokenSource.Token;
                Task.Factory.StartNew(() =>
                {
                    await SearchFoodAsync(o, maxLimit, FoodModel.b_food, q, null, null, ct2);
                    gotResult = true;
                }, ct1);
                while (!gotResult)
                {
                    // When you call abort Response.IsClientConnected will = false
                    if (!Response.IsClientConnected)
                    {
                        tokenSource1.Cancel();
                        tokenSource2.Cancel();
                        break;
                    }
                    Thread.Sleep(1000 * 10);
                }
            };
            return PartialView();
        }
        /// <summary>
        /// search foods
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="q"></param>
        /// <param name="filters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [NonAction]
        protected async Task<List<Food>> SearchFoodAsync(int offset, int limit, string filters, string q, CancellationToken ct2)
        {
            var dtblFood = await LSocialBL.SearchFoodAsync(offset, limit, filters, q, ct2);
            //--- few more code lines
        }
