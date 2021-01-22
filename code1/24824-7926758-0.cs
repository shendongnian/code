    Imports System.Runtime.CompilerServices
    Imports System.ComponentModel
    Imports System.Linq.Expressions
    Public Module HtmlHelpers
        Private Function GetNonNullableModelType(modelMetadata As ModelMetadata) As Type
            Dim realModelType = modelMetadata.ModelType
    
            Dim underlyingType = Nullable.GetUnderlyingType(realModelType)
    
            If Not underlyingType Is Nothing Then
                realModelType = underlyingType
            End If
    
            Return realModelType
        End Function
    
        Private ReadOnly SingleEmptyItem() As SelectListItem = {New SelectListItem() With {.Text = "", .Value = ""}}
    
        Private Function GetEnumDescription(Of TEnum)(value As TEnum) As String
            Dim fi = value.GetType().GetField(value.ToString())
    
            Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
    
            If Not attributes Is Nothing AndAlso attributes.Length > 0 Then
                Return attributes(0).Description
            Else
                Return value.ToString()
            End If
        End Function
    
        <Extension()>
        Public Function EnumDropDownListFor(Of TModel, TEnum)(ByVal htmlHelper As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TEnum))) As MvcHtmlString
            Return EnumDropDownListFor(htmlHelper, expression, Nothing)
        End Function
    
        <Extension()>
        Public Function EnumDropDownListFor(Of TModel, TEnum)(ByVal htmlHelper As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TEnum)), htmlAttributes As Object) As MvcHtmlString
            Dim metaData As ModelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData)
            Dim enumType As Type = GetNonNullableModelType(metaData)
            Dim values As IEnumerable(Of TEnum) = [Enum].GetValues(enumType).Cast(Of TEnum)()
    
            Dim items As IEnumerable(Of SelectListItem) = From value In values
                Select New SelectListItem With
                {
                    .Text = GetEnumDescription(value),
                    .Value = value.ToString(),
                    .Selected = value.Equals(metaData.Model)
                }
    
            ' If the enum is nullable, add an 'empty' item to the collection
            If metaData.IsNullableValueType Then
                items = SingleEmptyItem.Concat(items)
            End If
    
            Return htmlHelper.DropDownListFor(expression, items, htmlAttributes)
        End Function
    End Module
