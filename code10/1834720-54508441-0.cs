using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("Layout/Wrap Layout Group", 153)]
public class WrapLayoutGroup : LayoutGroup
{
    [SerializeField] protected Vector2 m_Spacing = Vector2.zero;
    public Vector2 spacing { get { return m_Spacing; } set { SetProperty(ref m_Spacing, value); } }
    [SerializeField] protected bool m_Horizontal = true;
    public bool horizontal { get { return m_Horizontal; } set { SetProperty(ref m_Horizontal, value); } }
    private float availableWidth { get { return rectTransform.rect.width - padding.horizontal + spacing.x; } }
    private const float MIN_HEIGHT = 80;
    private int preferredRows = 1;
    private float calculatedHeight = MIN_HEIGHT;
    private Vector2[] childPositions = new Vector2[0];
    protected WrapLayoutGroup()
    { }
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
    }
#endif
    public override void CalculateLayoutInputVertical()
    {
        calculatePositionsAndRequiredSize();
        SetLayoutInputForAxis(calculatedHeight, calculatedHeight, -1, 1);
    }
    public override void SetLayoutHorizontal() { }
    public override void SetLayoutVertical()
    {
        SetChildren();
    }
    private void SetChildren()
    {
        for (int i = 0; i < rectChildren.Count; i++)
        {
            RectTransform child = rectChildren[i];
            SetChildAlongAxis(child, 0, childPositions[i].x, LayoutUtility.GetPreferredWidth(child));
            SetChildAlongAxis(child, 1, childPositions[i].y, LayoutUtility.GetPreferredHeight(child));
        }
    }
    private void calculatePositionsAndRequiredSize()
    {
        childPositions = new Vector2[rectChildren.Count];
        Vector2 startOffset = new Vector2(
            GetStartOffset(0, 0),
            GetStartOffset(1, 0)
        );
        Vector2 currentOffset = new Vector2(
            startOffset.x,
            startOffset.y
        );
        float childHeight = 0;
        float childWidth = 0;
        float maxChildHeightInRow = 0;
        int currentRow = 1;
        for (int i = 0; i < rectChildren.Count; i++)
        {
            childHeight = LayoutUtility.GetPreferredHeight(rectChildren[i]);
            childWidth = LayoutUtility.GetPreferredWidth(rectChildren[i]);
            //check for new row start
            if (currentOffset.x + spacing.x + childWidth > availableWidth && i != 0)
            {
                currentOffset.x = startOffset.x;
                currentOffset.y += maxChildHeightInRow + spacing.y;
                currentRow++;
                maxChildHeightInRow = 0;
            }
            childPositions[i] = new Vector2(
                currentOffset.x,
                currentOffset.y
            );
            //update offset
            maxChildHeightInRow = Mathf.Max(maxChildHeightInRow, childHeight);
            currentOffset.x += childWidth + spacing.x;
        }
        //update groups preferred dimensions
        preferredRows = currentRow;
        calculatedHeight = currentOffset.y + maxChildHeightInRow + padding.vertical - spacing.y;
    }
}
