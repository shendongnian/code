    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    public class InputFieldWithOutKeyboard : InputField
    {
    protected override void Start()
    {
    keyboardType = (TouchScreenKeyboardType)(-1);
    }
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
    base.OnPointerDown(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
    Vector2 mPos;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(textComponent.rectTransform, eventData.position, eventData.pressEventCamera, out mPos);
    Vector2 cPos = GetLocalCaretPosition();
    int pos = GetCharacterIndexFromPosition(mPos);
    Debug.Log("pos = " + pos);
    GameObject.FindWithTag("canvas").GetComponent<Calculator>().carretPostion = pos;
    GameObject.FindWithTag("canvas").GetComponent<Calculator>().carretVector = mPos;
    base.OnPointerUp(eventData);
    }
    public Vector2 GetLocalCaretPosition()
    {
    // if (isFocused)
    // {
    TextGenerator gen = m_TextComponent.cachedTextGenerator;
    UICharInfo charInfo = gen.characters[caretPosition];
    float x = (charInfo.cursorPos.x + charInfo.charWidth) / m_TextComponent.pixelsPerUnit;
    float y = (charInfo.cursorPos.y) / m_TextComponent.pixelsPerUnit;
    Debug.Log("x=" + x + "y=" + y);
    return new Vector2(x, y);
    // }
    // else
    // return new Vector2(0f, 0f);
    }
    private int GetCharacterIndexFromPosition(Vector2 pos)
    {
    TextGenerator gen = m_TextComponent.cachedTextGenerator;
    if (gen.lineCount == 0)
    return 0;
    int line = GetUnclampedCharacterLineFromPosition(pos, gen);
    if (line < 0)
    return 0;
    if (line >= gen.lineCount)
    return gen.characterCountVisible;
    int startCharIndex = gen.lines[line].startCharIdx;
    int endCharIndex = GetLineEndPosition(gen, line);
    for (int i = startCharIndex; i < endCharIndex; i++)
    {
    if (i >= gen.characterCountVisible)
    break;
    UICharInfo charInfo = gen.characters[i];
    Vector2 charPos = charInfo.cursorPos / m_TextComponent.pixelsPerUnit;
    float distToCharStart = pos.x - charPos.x;
    float distToCharEnd = charPos.x + (charInfo.charWidth / m_TextComponent.pixelsPerUnit) - pos.x;
    if (distToCharStart < distToCharEnd)
    return i;
    }
    return endCharIndex;
    }
    private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator)
    {
    // transform y to local scale
    float y = pos.y * m_TextComponent.pixelsPerUnit;
    float lastBottomY = 0.0f;
    for (int i = 0; i < generator.lineCount; ++i)
    {
    float topY = generator.lines[i].topY;
    float bottomY = topY - generator.lines[i].height;
    // pos is somewhere in the leading above this line
    if (y > topY)
    {
    // determine which line we're closer to
    float leading = topY - lastBottomY;
    if (y > topY - 0.5f * leading)
    return i - 1;
    else
    return i;
    }
    if (y > bottomY)
    return i;
    lastBottomY = bottomY;
    }
    // Position is after last line.
    return generator.lineCount;
    }
    private static int GetLineEndPosition(TextGenerator gen, int line)
    {
    line = Mathf.Max(line, 0);
    if (line + 1 < gen.lines.Count)
    return gen.lines[line + 1].startCharIdx - 1;
    return gen.characterCountVisible;
    }
    }
