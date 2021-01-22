    [Route("~/Policy/PriorAddressDelete/{sequence}")]
    public ActionResult PriorAddressDelete(int sequence)
    {
      Policy.RemoveScheduledPriorAddressItem(sequence);
      return RedirectToAction("Information", new { id = Policy.Id });
    }
