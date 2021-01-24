		/// <summary>
		/// Creates a Item From Body
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///     POST /api/Items/CreateViaBody
		///     {
		///        "code": "0001",
		///        "description": "Item1"
		///     }
		///
		/// </remarks>
		/// <param cref="CreateItemViewModel" name="createItemViewModel">Create Item View Model</param>
		/// <returns>A newly created Item</returns>
		/// <response code="201" cref="CreateItemViewModel">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>            
		[HttpPost("CreateViaBody")]
		[ProducesResponseType((int)HttpStatusCode.Created)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public ActionResult<CreateItemViewModel> CreateViaBody([FromBody]CreateItemViewModel createItemViewModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			return Created("", createItemViewModel);
		}
