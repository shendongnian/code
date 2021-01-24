        [HttpGet]
        [Route("{itemId}")]
        public async Task<IHttpActionResult> GetItemById(int eventId, [FromUri]EventTabs tabId)
        {
                 
            ServiceResponse<ItemDto> result = await _itemDispatcher.GetItemById(itemId);
            return WrapResponse(result);
        }
