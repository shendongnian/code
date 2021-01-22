        [ResultType(typeof(BASE_Product))]
        [ResultType(typeof(BASE_ItemPrice))]
        [ResultType(typeof(BASE_VendorItem))]
        [ResultType(typeof(BASE_ProductAttachment))]
        public IMultipleResults BASE_Product_Retrieves([Parameter(Name = "ProductId", DbType = "Int")] System.Nullable<int> productId, [Parameter(Name = "Version", DbType = "Int")] System.Nullable<int> version)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), productId, version);
            return ((IMultipleResults)(result.ReturnValue));
        }
