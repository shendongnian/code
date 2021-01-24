	if (arInvoice != null)
	{
		//Release Invoice
		PXLongOperation.StartOperation(this, delegate ()
		{
			soInvoiceGraph.Clear();
			soInvoiceGraph.Document.Current = arInvoice;
			soInvoiceGraph.release.Press();
		
			//Lookup issue, add to list, and call release
			INRegister issue = PXSelect<INRegister,
				Where<INRegister.sOShipmentNbr, Equal<Required<INRegister.sOShipmentNbr>>,
				And<INRegister.docType, Equal<Required<INRegister.docType>>>>>
				.Select(this, asnShipment.ShipmentNbr, INDocType.Issue);
			//Check setup flag and issue status
			if (sosetup.Current.AutoReleaseIN == true &&
				issue.Hold == false &&
				issue.Released == false)
			{
				List<INRegister> issues = new List<INRegister>();
				issues.Add(issue);
				INDocumentRelease.ReleaseDoc(issues, false);
			}
		});
	}
