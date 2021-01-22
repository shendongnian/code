    Public Interface ISkuItem
        Property SKU() As String
    End Interface
    
    Public Interface ICartItem
        Inherits ISkuItem
        Shadows Property SKU() As String
    End Interface
    
    Public Class CartItem
        Implements ICartItem
    
        Private _sku As String
        Public Property SKU() As String Implements ICartItem.SKU, ISkuItem.SKU
            Get
                Return _sku
            End Get
            Set(ByVal value As String)
                _sku = value
            End Set
        End Property
    
    End Class
