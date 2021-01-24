[ 1, 2, 3 ]
You can then receive it:
[HttpDelete("/api/Entity/Delete")]
public async Task<IActionResult> Delete([FromBody] int[] ids)
{
}
