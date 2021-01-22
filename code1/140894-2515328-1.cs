protected String ShowListingTitle( int field1,string field2 )
{
    Listing listing = ( Listing ) row;
    return NicelyFormattedString( listing.field1, listing.field2, ... );
}
