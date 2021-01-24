        /// <summary>
		/// Creates a Item From Query (Default)
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Items/CreateViaQuery
		///     {
		///        "code": "0001",
		///        "description": "Item1"
		///     }
		///
		/// </remarks>
		/// <param cref="CreateItemViewModel" name="createItemViewModel">Create Item View Model</param>
		/// <returns>A newly created Item</returns>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>            
		[HttpPost("CreateViaQuery")]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public ActionResult<CreateItemViewModel> CreateViaQuery(CreateItemViewModel createItemViewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			return Created("", createItemViewModel);
		}
