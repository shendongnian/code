    private void dataGridView1_CellContentClick( object sender, DataGridViewCellEventArgs e )
    {
    	if ( e.RowIndex >= 0 )
    	{
    		if ( e.ColumnIndex == this.colDelete.Index )
    		{
    			var pallet = this.dataGridView1.Rows[ e.RowIndex ].DataBoundItem as PrimalPallet;
    			this.DeletePalletByID( pallet.ID );
    		}
    		else if ( e.ColumnIndex == this.colEdit.Index )
    		{
    			var pallet = this.dataGridView1.Rows[ e.RowIndex ].DataBoundItem as PrimalPallet;
    			// etc.
    		}
    	}
    }
